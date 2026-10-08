using System.Windows;
using System.Windows.Controls;

namespace QET.Styles.Controls;

public class Gauge : Control
{
    static Gauge()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(Gauge), new FrameworkPropertyMetadata(typeof(Gauge)));
    }



    public double Value
    {
        get { return (double)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(nameof(Value), typeof(double), typeof(Gauge), new FrameworkPropertyMetadata(0.0));


}
