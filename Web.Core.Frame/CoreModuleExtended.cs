using Autofac;
using CLL.LLClasses.Models;
using Web.Core.Frame.Interfaces.UseCases;
using Web.Core.Frame.UseCases;

namespace Web.Core.Frame
{
    public partial class CoreModuleExtended : Module
    {
        protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<HomeUseCase>().As<IHomeUseCase>().InstancePerLifetimeScope();

            builder.RegisterType<Owin_FormActionUseCase>().As<IOwin_FormActionUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_LastWorkingPageUseCase>().As<IOwin_LastWorkingPageUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_RoleUseCase>().As<IOwin_RoleUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_RolePermissionUseCase>().As<IOwin_RolePermissionUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_UserUseCase>().As<IOwin_UserUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_UserClaimsUseCase>().As<IOwin_UserClaimsUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_UserLoginTrailUseCase>().As<IOwin_UserLoginTrailUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_UserPasswordResetInfoUseCase>().As<IOwin_UserPasswordResetInfoUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_UserPrefferencesSettingsUseCase>().As<IOwin_UserPrefferencesSettingsUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_UserRoleUseCase>().As<IOwin_UserRoleUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_UserRolesUseCase>().As<IOwin_UserRolesUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<Owin_UserStatusChangeHistoryUseCase>().As<IOwin_UserStatusChangeHistoryUseCase>().InstancePerLifetimeScope();

            builder.RegisterType<Auth_UseCase>().As<IAuth_UseCase>().InstancePerLifetimeScope();

            //General : Start
            builder.RegisterType<Gen_ServiceStatusUseCase>().As<IGen_ServiceStatusUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<Gen_EventInfoUseCase>().As<IGen_EventInfoUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<Gen_EventCategoryUseCase>().As<IGen_EventCategoryUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<Gen_UserUnitUseCase>().As<IGen_UserUnitUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<Gen_UnitUseCase>().As<IGen_UnitUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<Gen_EventFileInfoUseCase>().As<IGen_EventFileInfoUseCase>().InstancePerLifetimeScope();





        }
	}
}