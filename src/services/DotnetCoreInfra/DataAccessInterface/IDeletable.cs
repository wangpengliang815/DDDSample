﻿using System;

namespace DotnetCoreInfra.DataAccessInterface
{
    /// <summary>
    /// 可逻辑删除的对象
    /// </summary>
    public interface IDeletable
    {
        bool? IsDeleted { get; set; }
    }
}
