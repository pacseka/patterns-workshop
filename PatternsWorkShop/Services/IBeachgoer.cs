using PatternsWorkShop.Services.Visitor;

namespace PatternsWorkShop.Services;

public interface IBeachgoer
{
	public void Accept(IBeachVisitor visitor);
}
