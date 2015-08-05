using BottleOfRum.Business;
using SimpleInjector;

namespace BottleOfRum.Web.UI
{
    public class InjectorContainerFactory
    {
        public Container BuildSimpleInjectorContainer()
        {
            var container = new Container();
            container.Register<ITreasureCalculator, TreasureCalculator>();
            //container.Register<ITreasureCalculator, TreasureCalculatorCheat>();
            return container;
        }
    }
}