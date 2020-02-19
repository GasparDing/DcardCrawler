using AutoMapper;
using DcardCrawler.Data;
using DcardCrawler.Model;
using Serilog;
using System;
using System.Linq;

namespace DcardCrawler
{
    public class Initial
    {
        public static IMapper Mapper { get; private set; }

        public static void Log(string name)
        {
            Serilog.Log.Logger = new LoggerConfiguration().WriteTo.File(AppDomain.CurrentDomain.BaseDirectory + name, rollingInterval: RollingInterval.Day).CreateLogger();
        }

        public static void AutoMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Comment, CommentViewModel>();
                cfg.CreateMap<CommentViewModel, Comment>();

                cfg.CreateMap<MediaViewModel, Medium>();

                cfg.CreateMap<MediaMeta, MediaMetaViewModel>();
                cfg.CreateMap<MediaMetaViewModel, MediaMeta>()
                    .ForMember(e => e.Tags, m => m.MapFrom(x => x.Tags.Select(t => new Tag { Value = t })));

                cfg.CreateMap<Post, PostViewModel>();
                //cfg.CreateMap<PostViewModel, Post>()
                //    .ForMember(e => e.Media, m => m.MapFrom(x => x.Topics.Select(t => new Topic { Value = t })))
                //    .ForMember(e => e.Tags, m => m.MapFrom(x => x.Tags.Select(t => new Tag { Value = t })))
                //    .ForMember(e => e.Topics, m => m.MapFrom(x => x.Topics.Select(t => new Topic { Value = t })))
                //    .ForMember(e => e.Topics, m => m.MapFrom(x => x.Topics.Select(t => new Topic { Value = t })))
                //    .ForMember(e => e.Topics, m => m.MapFrom(x => x.Topics.Select(t => new Topic { Value = t })));


                cfg.CreateMap<Tag, TagViewModel>();
                cfg.CreateMap<TagViewModel, Tag>();

                cfg.CreateMap<Topic, TopicViewModel>();
                cfg.CreateMap<TopicViewModel, Topic>();
            });

# if DEBUG
            // only during development, validate your mappings; remove it before release
            //configuration.AssertConfigurationIsValid();
#endif
            // use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
            Initial.Mapper = configuration.CreateMapper();
        }
    }
}
