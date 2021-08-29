using Trip.Profile.Application.Common;

namespace Trip.Profile.Application.Feature.User.Queries.GetUserQuery
{
    public class GetUserQuery : IQuery<GetUserQueryResponse>
    {
        public int Id { get; set; }

        public int Email { get; set; }
    }
}
