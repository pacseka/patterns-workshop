namespace PatternsWorkShop.Services.Visitor;

public class SwimSuitBeachBoyVisitor : IBeachVisitor
{
	public void VisitBeachgoer(IBeachgoer beachgoer)
	{
		var beachBoy = beachgoer as BeachBoy;

		beachBoy.SwimSuite = "Swim Pant";
	}
}