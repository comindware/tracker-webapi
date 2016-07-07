// ***********************************************************************
// <author>Vasiliy Shapenko</author>
// <copyright company="Comindware">
//   Copyright (c) Comindware 2010-2016. All rights reserved.
// </copyright>
// <summary>
//   ServiceResolver.cs
// </summary>
// ***********************************************************************

using Comindware.Platform.WebApi.Client.LightInject;
using Comindware.Platform.WebApi.Contracts;

namespace Comindware.Platform.WebApi.Client
{
    public static class ServiceInterfaceFactory
    {
        private static readonly IServiceContainer Kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        static ServiceInterfaceFactory()
        {
            Kernel = new ServiceContainer();
            Kernel.Register<InterfaceInstanceParameters, IAppService>((factory, value) => new AppService(value));
            Kernel.Register<InterfaceInstanceParameters, IItemService>((factory, value) => new ItemService(value));
            Kernel.Register<InterfaceInstanceParameters, IItemsService>((factory, value) => new ItemsService(value));
            Kernel.Register<InterfaceInstanceParameters, IAttachmentService>((factory, value) => new AttachmentService(value));
            Kernel.Register<InterfaceInstanceParameters, ICommentsService>((factory, value) => new CommentsService(value));
            Kernel.Register<InterfaceInstanceParameters, IDatasetService>((factory, value) => new DatasetService(value));
            Kernel.Register<InterfaceInstanceParameters, IPrototypeService>((factory, value) => new PrototypeService(value));
            Kernel.Register<InterfaceInstanceParameters, ITimespentService>((factory, value) => new TimespentService(value));
            Kernel.Register<InterfaceInstanceParameters, IWorkflowService>((factory, value) => new WorkflowService(value));
            Kernel.Register<InterfaceInstanceParameters, IWorkspaceService>((factory, value) => new WorkspaceService(value));
            Kernel.Register<InterfaceInstanceParameters, IAuthenticationService>((factory, value) => new AuthenticationService(value));
            Kernel.Register<InterfaceInstanceParameters, IAccountService>((factory, value) => new AccountService(value));
            Kernel.Register<InterfaceInstanceParameters, IDataService>((factory, value) => new DataService(value));
            Kernel.Register<InterfaceInstanceParameters, IFavoriteService>((factory, value) => new FavoriteService(value));
        }

        public static T GetInterface<T>(InterfaceInstanceParameters parameters)
        {
            return Kernel.GetInstance<InterfaceInstanceParameters, T>(parameters);
        }
    }
}