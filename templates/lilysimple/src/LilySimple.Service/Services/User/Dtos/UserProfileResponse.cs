﻿using LilySimple.Services.Rbac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LilySimple.Services.User
{
    public class UserProfileResponse
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [JsonPropertyName("permissions")]
        public PermissionNodeResponse[] Permissions { get; set; }
    }
}
