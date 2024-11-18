using HiLandon.Core.Entities;

namespace HiLandon.Core.Repositories;
#if V2||V3
public interface ITagsRepository : IRepository<Tag>;
#endif