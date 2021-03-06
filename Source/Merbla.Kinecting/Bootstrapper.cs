using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Autofac;
using Caliburn.Micro;
using Caliburn.Micro.Autofac;
using Merbla.Kinecting.Common.Extensions;
using Merbla.Kinecting.Events;
using Merbla.Kinecting.ViewModels;
using Merbla.Kinecting.Views;
using Microsoft.Research.Kinect.Nui;

namespace Merbla.Kinecting
{
    public class Bootstrapper : AutofacBootstrapper<ShellViewModel>
    {

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            //var kinectRuntime = new Runtime();// Runtime.Kinects.First();
            var ea = new EventAggregator();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .AsSelf();

            //builder.RegisterInstance(kinectRuntime).SingleInstance();
           // builder.RegisterInstance(ea).SingleInstance();
        }
        protected override void OnExit(object sender, EventArgs e)
        {
            IoC.Get<Runtime>().Uninitialize();
            base.OnExit(sender, e);
        }


        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            base.OnStartup(sender, e);
          //  InitialiseRuntime(IoC.Get<Runtime>(), IoC.Get<IEventAggregator>());
        }

        private void InitialiseRuntime(Runtime _kinectRuntime, IEventAggregator eventAggregator)
        {
            _kinectRuntime.Initialise(() =>
                                          {
                                              //Wire Up Events
                                              _kinectRuntime.VideoFrameReady +=
                                                  (o, args) => eventAggregator.Publish(
                                                      new KinectingEvent<ImageFrameReadyEventArgs>(args));

                                              _kinectRuntime.SkeletonFrameReady +=
                                                  (o, args) => eventAggregator.Publish(
                                                      new KinectingEvent<SkeletonFrameReadyEventArgs>(args));

                                              _kinectRuntime.DepthFrameReady +=
                                                  (o, args) =>
                                                  eventAggregator.Publish(
                                                      new KinectingEvent<ImageFrameReadyEventArgs>(args));
                                             
                                          },
                                      (e) =>
                                          {
                                             // throw new Exception();
                                          });
        }
    }
}