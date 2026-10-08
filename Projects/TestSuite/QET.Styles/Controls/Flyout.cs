using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace QET.Styles.Controls;

[TemplatePart(Name = "PART_ToggleButton", Type = typeof(Button))]
public class Flyout : ItemsControl
{
    static Flyout()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(Flyout), new FrameworkPropertyMetadata(typeof(Flyout)));
    }



    public double CollapsedWidth
    {
        get { return (double)GetValue(CollapsedWidthProperty); }
        set { SetValue(CollapsedWidthProperty, value); }
    }

    // Using a DependencyProperty as the backing store for CollapsedWidth.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty CollapsedWidthProperty =
        DependencyProperty.Register(nameof(CollapsedWidth), typeof(double), typeof(Flyout), new PropertyMetadata(32.0));



    public double ExpandedWidth 
    {
        get { return (double)GetValue(ExpandedWidthProperty); }
        set { SetValue(ExpandedWidthProperty, value); }
    }

    // Using a DependencyProperty as the backing store for ExpandedWidth.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ExpandedWidthProperty =
        DependencyProperty.Register(nameof(ExpandedWidth), typeof(double), typeof(Flyout), new PropertyMetadata(64.0));



    public bool IsExpanded
    {
        get { return (bool)GetValue(IsExpandedProperty); }
        set { SetValue(IsExpandedProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IsExpanded.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IsExpandedProperty =
        DependencyProperty.Register(nameof(IsExpanded), typeof(bool), typeof(Flyout), new PropertyMetadata(false));



    public object Header
    {
        get { return (object)GetValue(HeaderProperty); }
        set { SetValue(HeaderProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register(nameof(Header), typeof(object), typeof(Flyout), new PropertyMetadata(string.Empty));



    private Button? toggleButton;

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        toggleButton = GetTemplateChild("PART_ToggleButton") as Button;
        if (toggleButton != null)
        {
            toggleButton.Click += (s, e) => IsExpanded = !IsExpanded;
        }
    }
}
