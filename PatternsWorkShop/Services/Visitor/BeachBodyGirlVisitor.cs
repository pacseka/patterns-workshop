namespace PatternsWorkShop.Services.Visitor;

public class BeachBodyGirlVisitor : IBeachVisitor
{
	public void VisitBeachgoer(IBeachgoer beachgoer)
	{
		var beachGirl = beachgoer as BeachGirl;

		beachGirl.BeachBody = "Slim";
	}
}
