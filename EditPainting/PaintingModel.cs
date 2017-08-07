using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;

namespace EditPainting
{
  public class PaintingModel
  {
    #region Fields

    private string savedDocument;
    private static char[] delimeters = new char[] { '|' };
    private static Random random = new Random(DateTime.Now.Millisecond);

    public DragElement dragElement = new DragElement();

    #endregion Fields

    public PaintingModel()
    {
      Shapes = new ObservableCollection<Shape>();
    }

    #region Properties

    public Size DocumentSize { get; set; } = new Size();
    public ObservableCollection<Shape> Shapes { get; set; }

    #endregion Properties

    #region Methods

    //IInputElement inputElement = null;
    //bool isDragging = false;
    //double xCoord = 0, yCoord = 0;

    public void AddNewRectangle(double width = 100, double height = 60)
    {
      var shape = new Rectangle()
      {
        Width = width,
        Height = height,
        Fill = Brushes.Red,
        RenderTransform = new TranslateTransform(
            random.Next((int)DocumentSize.Width) - (width / 2),
            random.Next((int)DocumentSize.Height) - (height / 2)
          )
      };
      shape.ContextMenu = CreateShapeContextMenu();
      //shape.MouseMove += ShapeMouseMove;
      shape.MouseLeftButtonUp += ShapeMouseLeftButtonUp;
      shape.MouseLeftButtonDown += ShapeMouseLeftButtonDown;
      shape.MouseRightButtonUp += ShapeMouseRightButtonUp;
      Shapes.Add(shape);
    }

    public void AddNewEllipse(double width = 100, double height = 60)
    {
      var shape = new Ellipse()
      {
        Width = width,
        Height = height,
        Fill = Brushes.Green,
        RenderTransform = new TranslateTransform(
            random.Next((int)DocumentSize.Width) - (width / 2),
            random.Next((int)DocumentSize.Height) - (height / 2)
          ),
      };

      shape.ContextMenu = CreateShapeContextMenu();
      //shape.MouseMove += ShapeMouseMove;
      shape.MouseLeftButtonDown += ShapeMouseLeftButtonDown;
      shape.MouseLeftButtonUp += ShapeMouseLeftButtonUp;
      shape.MouseRightButtonUp += ShapeMouseRightButtonUp;
      Shapes.Add(shape);
    }

    private void ShapeMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      this.dragElement.InputElement = sender as IInputElement;
      //if(sender is Shape)
      //{
      //  var shape = sender as Shape;
      //  Mouse.Capture(shape);
      //  isDragging = true;
      //}
    }

    private void ShapeMouseMove(object sender, MouseEventArgs e)
    {
      //if (isDragging)
      //{
      //  if(sender is Shape)
      //  {
      //    var shape = sender as Shape;
      //    //shape.RenderTransform.
      //  }
      //  //double x = e.GetPosition(ShapeDocument).X;
      //}
    }

    private void ShapeMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      this.dragElement.InputElement = null;
    }

    private void ShapeMouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
      if(sender is Shape)
      {
        var shape = sender as Shape;
        if (shape.ContextMenu != null)
        {
          shape.ContextMenu.PlacementTarget = shape;
          shape.ContextMenu.IsOpen = true;
        }
      }
    }

    private ContextMenu CreateShapeContextMenu()
    {
      var contextmenu = new ContextMenu();
      var mi = new MenuItem();
      //mi.Command = ;
      mi.Header = "Delete";
      //mi.Icon = ;
      contextmenu.Items.Add(mi);
      return contextmenu;
    }

    public void SaveShapes()
    {
      var sb = new StringBuilder();
      for (int idx = 0; idx < Shapes.Count; ++idx)
      {
        if (0 < idx) { sb.Append("|"); }
        sb.Append(XamlWriter.Save(Shapes[idx]));
      }
      savedDocument = sb.ToString();
    }

    public void LoadShapes()
    {
      Shapes.Clear();
      var shapes = savedDocument.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
      foreach (var shape in shapes)
      {
        StringReader stringReader = new StringReader(shape);
        XmlReader xmlReader = XmlReader.Create(stringReader);
        Shapes.Add(XamlReader.Load(xmlReader) as Shape);
      }
    }

    #endregion Methods
  }

  public class DragElement
  {
    bool isDragging = false;
    IInputElement inputElement = null;
    double x = 0, y = 0;

    public DragElement() { }

    public IInputElement InputElement
    {
      get { return this.inputElement; }
      set {
        this.inputElement = value;
        this.isDragging = true;
      }
    }

    public double X
    {
      get { return this.x; }
      set { this.x = value; }
    }

    public double Y
    {
      get { return this.y; }
      set { this.y = value; }
    }

    public bool IsDragging
    {
      get { return this.isDragging; }
      set { this.isDragging = value; }
    }
  }
}
