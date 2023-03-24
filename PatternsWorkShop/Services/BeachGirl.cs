using PatternsWorkShop.Services.Visitor;

namespace PatternsWorkShop.Services;

public class BeachGirl : IBeachgoer
{
	public string SwimSuite { get; set; } = "None";

	public string BeachBody { get; set; } = "Fat";

	public void Accept(IBeachVisitor visitor)
	{
		visitor.VisitBeachgoer(this);
	}
}