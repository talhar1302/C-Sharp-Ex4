﻿using System;

namespace Ex04.Menus.Interfaces
{
    public interface IMenuItem
    {
        string Title { get; }
        void Execute();
    }
}
