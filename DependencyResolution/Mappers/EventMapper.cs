using AutoMapper;
using ShiftManagementPortal.Core.Domain.Model;
using ShiftManagementPortal.DependencyResolution.Resolvers;
using ShiftManagementPortal.Infrastructure.Constants;
using ShiftManagementPortal.UI.ViewModel.Event;

namespace ShiftManagementPortal.DependencyResolution.Mappers
{
    public class EventMapper: Profile
    {
        public EventMapper()
        {
            CreateMap<Event, EventListItemViewModel>()
                .ForMember(
                    dest => dest.Url,
                    opt => opt.ResolveUsing<UrlResolver, RouteUrlInfo>(src =>
                        new RouteUrlInfo()
                        {
                            RouteName = EventConstants.GET_EVENT_BY_ID,
                            RouteParams = new {id = src.Id}
                        }
                    ));
        }
    }
}
