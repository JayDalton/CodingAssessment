using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace EditPainting
{
  /// <summary>
  /// Interaktionslogik für MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    #region Fields

    private PaintingModel model = new PaintingModel();

    #endregion Fields

    public MainWindow()
    {
      DataContext = model;
      InitializeComponent();
    }

    private void CanvasSizeChanged(object sender, SizeChangedEventArgs e)
    {
      model.DocumentSize = e.NewSize;
    }

    private void AddRectangleButton_Click(object sender, RoutedEventArgs e)
    {
      model.AddNewRectangle();
    }

    private void AddEllipseButton_Click(object sender, RoutedEventArgs e)
    {
      model.AddNewEllipse();
    }

    private void SaveAsButton_Click(object sender, RoutedEventArgs e)
    {
      model.SaveShapes();
    }

    private void LoadButon_Click(object sender, RoutedEventArgs e)
    {
      model.LoadShapes();
    }

    private void RevertButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void ShapeDocument_MouseDown(object sender, MouseButtonEventArgs e)
    {
      model.dragElement.X = Mouse.GetPosition(sender as IInputElement).X;
      model.dragElement.Y = Mouse.GetPosition(sender as IInputElement).Y;
      model.dragElement.InputElement.CaptureMouse();
    }

    private void ShapeDocument_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.LeftButton == MouseButtonState.Pressed)
      {
        model.dragElement.IsDragging = true;
      }

      if (model.dragElement.IsDragging && model.dragElement.InputElement != null)
      {
        // Retrieve the current position of the mouse.
        var newX = Mouse.GetPosition((IInputElement)sender).X;
        var newY = Mouse.GetPosition((IInputElement)sender).Y;



        // Reset the location of the object (add to sender's renderTransform
        // newPosition minus currentElement's position

        var rt = ((UIElement)model.dragElement.InputElement).RenderTransform;

        var offsetX = rt.Value.OffsetX;
        var offsetY = rt.Value.OffsetY;

        rt.SetValue(TranslateTransform.XProperty, offsetX + newX - model.dragElement.X);

        rt.SetValue(TranslateTransform.YProperty, offsetY + newY - model.dragElement.Y);


        // Update position of the mouse
        model.dragElement.X = newX;
        model.dragElement.Y = newY;
      }
    }

    private void ShapeDocument_MouseUp(object sender, MouseButtonEventArgs e)
    {
      if (model.dragElement.InputElement != null)
      {
        model.dragElement.InputElement.ReleaseMouseCapture();
      }
    }

  }
}
