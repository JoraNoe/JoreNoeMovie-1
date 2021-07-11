using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.DomainServices.TimerServices;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JoreNoeVideo.DomainServices.Tools
{
    /// <summary>
    /// 临时文件
    /// </summary>
    public static class RelitClass
    {
        public static IHttpRequestDomainService HttpRequestDomain { get; set; } = new HttpRequestDomainService();

        public static string removeNotNumber(string key, out bool IsJudge)
        {
            IsJudge = false;
            if (string.IsNullOrEmpty(Regex.Replace(key, @"[^\d]", "")))
                return key;

            IsJudge = true;
            return Regex.Replace(key, @"[^\d]*", "");
        }
        public static string removeNotNumber(string key)
        {
            return Regex.Replace(key, @"[^\d]*", "");
        }
        /// <summary>
        /// 展示类型的转换
        /// </summary>
        /// <param name="Definition">类型</param>
        /// <returns></returns>
        public static string JudgeMovieDefinition(string Definition)
        {
            if (Definition == ConstantsKey.JORENOEVIDEO_MOVIE_HD)
            {
                return ConstantsKey.JORENOEVIDEO_MOVIEHD;
            }
            else if (Definition == ConstantsKey.JORENOEVIDEO_MOVIEHD_CHINASE)
            {
                return ConstantsKey.JORENOEVIDEO_MOVIEHDCHINAES;
            }

            else if (Definition == ConstantsKey.JORENOEVIDEO_MOVIE_BLUELIGHT)
            {
                return ConstantsKey.JORENOEVIDEO_MOVIEBLUELIGHT;
            }

            else if (Definition == ConstantsKey.JORENOEVIDEO_MOVIE_TC)
            {
                return ConstantsKey.JORENOEVIDEO_MOVIETC;
            }

            else if (Definition == ConstantsKey.JORENOEVIDEO_MOVIE_TCCHINASE)
            {
                return ConstantsKey.JORENOEVIDEO_MOVIETCCHINASE;
            }

            else if (Definition == ConstantsKey.JORENOEVIDEO_MOVIE_SP)
            {
                return ConstantsKey.JORENOEVIDEO_MOVIESP;
            }
            else if (Definition == ConstantsKey.JORENOEVIDEO_MOVIE_Hc)
            {
                return ConstantsKey.JORENOEVIDEO_MOVIEHC;
            }
            else
            {
                return Definition;
            }

        }
    }

}
