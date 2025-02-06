using System;
using System.Collections.Generic;

namespace ExpenseManagement.Repository.Model.EntityModel;

public partial class FriendDetail
{
    public short Id { get; set; }

    public short UserId { get; set; }

    public short FriendId { get; set; }
}
