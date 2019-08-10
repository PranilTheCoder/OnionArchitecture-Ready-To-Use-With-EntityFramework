using Unity;
using Unity.Lifetime;

namespace PranilArchitecture.Resolver
{
	internal class RegisterComponent : IRegisterComponent
	{
		private readonly IUnityContainer _container;

		public RegisterComponent(IUnityContainer container)
		{
			this._container = container;
		}

		public void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
		{
			if (withInterception)
			{
			}
			else
			{
				this._container.RegisterType<TFrom, TTo>();
			}
		}

		public void RegisterTypeWithControlledLifeTime<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
		{
			this._container.RegisterType<TFrom, TTo>(new
			ContainerControlledLifetimeManager());
		}
	}
}
