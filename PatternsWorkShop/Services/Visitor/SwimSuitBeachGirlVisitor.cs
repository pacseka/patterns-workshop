namespace PatternsWorkShop.Services.Visitor;

public class SwimSuitBeachGirlVisitor : IBeachVisitor
{
	public void VisitBeachgoer(IBeachgoer beachgoer)
	{
		var beachGirl = beachgoer as BeachGirl;

		beachGirl.SwimSuite = "Monokini";
	}
}