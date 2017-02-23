using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/*
 This class will be used to store all the global variable
 */
/// </summary>
public static class Global
{
    static string _getName;

    /*This propertty will return the name of the movie, actor or director*/
    public static string GetName
    {
        get
        {
            return _getName;
        }

        set
        {
            _getName = value ;
        }

    }
}