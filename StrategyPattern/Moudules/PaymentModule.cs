using System.Reflection;
using Autofac;
using StrategyPattern.Interfaces;

namespace StrategyPattern.Moudules
{
    public class PaymentModule : Autofac.Module
    {
        public PaymentModule(ContainerBuilder builder)
        {
            Load(builder);
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.IsAssignableTo<IPaymentStrategy>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.Register<IDictionary<string, IPaymentStrategy>>(c =>
            {
                var strategies = c.Resolve<IEnumerable<IPaymentStrategy>>();
                return strategies.ToDictionary(
                    s => s.GetType().Name.Replace("PaymentStrategy", ""),
                    s => s);
            }).SingleInstance();
        }
    }
}