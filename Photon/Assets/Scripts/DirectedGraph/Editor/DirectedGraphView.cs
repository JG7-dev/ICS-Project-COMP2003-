using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using System;
using System.Linq;

public class DirectedGraphView : GraphView
{
    public readonly Vector2 DefaultNodeSize = new Vector2(150, 200);
    public DirectedGraphView()
    {
        styleSheets.Add(Resources.Load<StyleSheet>("DirectedGraph"));
        SetupZoom(ContentZoomer.DefaultMinScale,ContentZoomer.DefaultMaxScale);

        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());

        var grid = new GridBackground();
        Insert(0, grid);
        grid.StretchToParentSize();

        AddElement(GenerateEntryPointNode());
    }

    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
        var compatiblePorts = new List<Port>();
        ports.ForEach((port) =>
       {
           if(startPort != port && startPort.node != port.node)
           {
               compatiblePorts.Add(port);
           }

       });
        return compatiblePorts;
    }

    private Port GeneratePort(DGNode node, Direction portDirection, Port.Capacity capacity = Port.Capacity.Single)
    {
        return node.InstantiatePort(Orientation.Horizontal, portDirection, capacity, typeof(float)); //arbitrairy type
    }
    private DGNode GenerateEntryPointNode()  //Generates the first Node of any new Directed Graph
    {
        var node = new DGNode
        {
            title = "START",
            GUID = Guid.NewGuid().ToString(), //Generates an ID using inbuilt Unity system
            Entry = true
        };

        var generatedPort = GeneratePort(node, Direction.Output);
        generatedPort.portName = "Next";
        node.outputContainer.Add(generatedPort);

        node.capabilities &= ~Capabilities.Movable; //Removes ability to Move and remove Start Node
        node.capabilities &= ~Capabilities.Deletable;

        node.RefreshExpandedState(); //Refreshes node
        node.RefreshPorts();

        node.SetPosition(new Rect(100, 200, 100, 150));
        return node;
    }

    public void CreateNode(string nodeName)
    {
        AddElement(CreateDirectedGraphNode(nodeName));
    }

    internal DGNode CreateDirectedGraphNode(string nodeName)
    {
        var node = new DGNode
        {
            NodeLabel = nodeName,
            title = nodeName,
            GUID = Guid.NewGuid().ToString(), //Generates an ID using Unity
            NodeDialog = new DGDialog(""), //NodeData
            Entry = false
        };

        node.styleSheets.Add(Resources.Load<StyleSheet>("Node"));

        //Input Ports
        var inputPort = GeneratePort(node, Direction.Input, Port.Capacity.Multi);
        inputPort.portName = "Input";
        node.inputContainer.Add(inputPort);

        //Output Ports
        var button = new Button(() => { AddOutputPort(node); });
        button.text = "New Link";
        node.titleContainer.Add(button);

        //dialog text
        var textField = new TextField(string.Empty);
        textField.RegisterValueChangedCallback(evt =>
        {
            node.NodeDialog.dialog = evt.newValue;
        });
        textField.SetValueWithoutNotify(node.title);
        node.mainContainer.Add(textField);

        node.RefreshPorts();
        node.RefreshExpandedState();
        node.SetPosition(new Rect(Vector2.zero,DefaultNodeSize));

        return node;
    }

    public void AddOutputPort(DGNode node, string overiddenPortName = "")
    {
        var generatedPort = GeneratePort(node, Direction.Output);

        var oldLabel = generatedPort.contentContainer.Q<Label>("type");
        generatedPort.contentContainer.Remove(oldLabel);

        var outputPortCount = node.outputContainer.Query("connector").ToList().Count;
        var outputPortName = $"Option {outputPortCount + 1}";

        var portName = string.IsNullOrEmpty(overiddenPortName) 
            ? $"Option {outputPortCount + 1}" 
            : overiddenPortName;

        var textField = new TextField
        {
            name = string.Empty,
            value = outputPortName
        };
        textField.RegisterValueChangedCallback(evt => generatedPort.portName = evt.newValue);

        generatedPort.contentContainer.Add(new Label("   "));

        generatedPort.contentContainer.Add(textField);

        var deleteButton = new Button(() => RemovePort(node, generatedPort))
        {
            text = "X"
        };
        generatedPort.Add(deleteButton);

        generatedPort.portName = portName;

        node.outputContainer.Add(generatedPort);
        node.RefreshExpandedState(); //Refreshes node
        node.RefreshPorts();
    }

    private void RemovePort(Node node, Port socket)
    {
        var targetEdge = edges.ToList()
            .Where(x => x.output.portName == socket.portName && x.output.node == socket.node);
        if (targetEdge.Any())
        {
            var edge = targetEdge.First();
            edge.input.Disconnect(edge);
            RemoveElement(targetEdge.First());
        }

        node.outputContainer.Remove(socket);
        node.RefreshPorts();
        node.RefreshExpandedState();
    }
}
