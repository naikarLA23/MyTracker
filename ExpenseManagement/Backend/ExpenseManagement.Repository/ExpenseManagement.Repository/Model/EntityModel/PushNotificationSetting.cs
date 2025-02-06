using System;
using System.Collections.Generic;

namespace ExpenseManagement.Repository.Model.EntityModel;

public partial class PushNotificationSetting
{
    public short UserId { get; set; }

    public bool AllowPushNotification { get; set; }

    public short? AlertTypeId { get; set; }
}
