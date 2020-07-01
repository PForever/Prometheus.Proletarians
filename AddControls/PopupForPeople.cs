using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AddControls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:AddControls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:AddControls;assembly=AddControls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:PopupForPeople/>
    ///
    /// </summary>
    public class PopupForPeople : Popup
    {
        static PopupForPeople()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PopupForPeople), new FrameworkPropertyMetadata(typeof(PopupForPeople)));
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if(!(Child is { } child)) return;
            _isMoving = true;
            _previouslyPosition = PointToScreen(e.GetPosition(this));
            Mouse.Capture(child, CaptureMode.SubTree);
            //CaptureMouse();
            base.OnMouseLeftButtonDown(e);
        }

        private bool _isMoving;
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            _isMoving = false;
            Mouse.Capture(null);
            //ReleaseMouseCapture();
            base.OnMouseLeftButtonUp(e);
        }

        private Point _previouslyPosition;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            
            if (_isMoving)
            {
                var previouslyPosition = _previouslyPosition;
                var currentPosition = _previouslyPosition = PointToScreen(e.GetPosition(this));
                var change = currentPosition - previouslyPosition;
                HorizontalOffset += change.X;
                VerticalOffset += change.Y;
                // Package the data.
                //DataObject data = new DataObject();
                //data.SetData(DataFormats.StringFormat, this.Fill.ToString());
                //data.SetData("Double", circleUI.Height);
                //data.SetData("Object", this);

                // Inititate the drag-and-drop operation.
                //DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
            base.OnMouseMove(e);
        }
    }
}
