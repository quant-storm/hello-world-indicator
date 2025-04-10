using System.Drawing;
using TradingPlatform.BusinessLayer;

/// Defines a custom indicator by inheriting from Quantower's 
/// base Indicator class
namespace HelloWorldIndicator
{
  // This class extends the base Indicator class
  public class HelloWorldIndicator : Indicator
  {
    // Holds a reference to the built-in EMA indicator
    private Indicator _ema;

    // Constructor: sets basic metadata and visual configuration
    public HelloWorldIndicator()
    {
      Name = "My Indicator";
      Description = "Hello World Indicator"; 
      SeparateWindow = false;
      _ema = null;
      AddLineSeries("EMA 50", Color.Magenta);
    }

    // Called once during the initialization of the indicator
    protected override void OnInit()
    {
      base.OnInit();
      AddIndicator(_ema = Core.Indicators.BuiltIn.EMA(50, PriceType.Close));
    }

    // Method is called when a price data updates. 
    protected override void OnUpdate(UpdateArgs args)
    {
      base.OnUpdate(args);
      SetValue(_ema.GetValue());
    }

    // Called when the indicator is removed / destroyed
    public override void Dispose()
    {
      base.Dispose();
      _ema?.Dispose();
      _ema = null;
    }

    // Short name displayed in the UI
    public override string ShortName => "HWI";
  }
}
