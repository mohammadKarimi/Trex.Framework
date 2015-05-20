namespace Trex.Framework.Controls.Droid
{
    using System;
    using System.Collections.Generic;
    using Android.Content;
    using Android.Graphics;
    using Xamarin.Forms.Platform.Android;
    using Xamarin.Forms;

    public interface ITypefaceCache
    {
        void StoreTypeface(string key, Typeface typeface);

        void RemoveTypeface(string key);

        Typeface RetrieveTypeface(string key);
    }
    public static class TypefaceCache
    {
        private static ITypefaceCache sharedCache;
        public static ITypefaceCache SharedCache
        {
            get
            {
                if (sharedCache == null)
                {
                    sharedCache = new DefaultTypefaceCache();
                }
                return sharedCache;
            }
            set
            {
                if (sharedCache != null && sharedCache.GetType() == typeof(DefaultTypefaceCache))
                {
                    ((DefaultTypefaceCache)sharedCache).PurgeCache();
                }
                sharedCache = value;
            }
        }
    }
    internal class DefaultTypefaceCache : ITypefaceCache
    {
        private Dictionary<string, Typeface> _cacheDict;
        public DefaultTypefaceCache()
        {
            _cacheDict = new Dictionary<string, Typeface>();
        }
        public Typeface RetrieveTypeface(string key)
        {
            if (_cacheDict.ContainsKey(key))
            {
                return _cacheDict[key];
            }
            else
            {
                return null;
            }
        }
        public void StoreTypeface(string key, Typeface typeface)
        {
            _cacheDict[key] = typeface;
        }
        public void RemoveTypeface(string key)
        {
            _cacheDict.Remove(key);
        }
        public void PurgeCache()
        {
            _cacheDict = new Dictionary<string, Typeface>();
        }
    }
    public static class FontExtensions
    {

        /// <summary>
        /// This method returns typeface for given typeface using following rules:
        /// 1. Lookup in the cache
        /// 2. If not found, look in the assets in the fonts folder. Save your font under its FontFamily name. 
        /// If no extension is written in the family name .ttf is asumed
        /// 3. If not found look in the files under fonts/ folder
        /// If no extension is written in the family name .ttf is asumed
        /// 4. If not found, try to return typeface from Xamarin.Forms ToTypeface() method
        /// 5. If not successfull, return Typeface.Default
        /// </summary>
        /// <returns>The extended typeface.</returns>
        /// <param name="font">Font</param>
        /// <param name="context">Android Context</param>
        public static Typeface ToExtendedTypeface(this Font font, Context context)
        {
            Typeface typeface = null;
            //1. Lookup in the cache
            var hashKey = font.ToHasmapKey();
            typeface = TypefaceCache.SharedCache.RetrieveTypeface(hashKey);

            //2. If not found, try custom asset folder
            if (typeface == null && !string.IsNullOrEmpty(font.FontFamily))
            {
                string filename = font.FontFamily;
                //if no extension given then assume and add .ttf
                if (filename.LastIndexOf(".", System.StringComparison.Ordinal) != filename.Length - 4)
                {
                    filename = string.Format("{0}.ttf", filename);
                }
                try
                {
                    var path = "fonts/" + filename;
                    typeface = Typeface.CreateFromAsset(context.Assets, path);
                }
                catch
                {
                    try
                    {
                        typeface = Typeface.CreateFromFile("fonts/" + filename);
                    }
                    catch
                    {
                    }
                }
            }
            //3. If not found, fall back to default Xamarin.Forms implementation to load system font
            if (typeface == null)
            {
                typeface = font.ToTypeface();
            }

            if (typeface == null)
            {
                typeface = Typeface.Default;
            }
            TypefaceCache.SharedCache.StoreTypeface(hashKey, typeface);
            return typeface;
        }
        public static Typeface ToExtendedTypeface(this string fontFamily, double fontSize, string namedSize, int fontAttributes, Context context)
        {
            Typeface typeface = null;
            var hashKey = ToHasmapKeyWithFontFamily(fontFamily, fontSize, namedSize, fontAttributes);
            typeface = TypefaceCache.SharedCache.RetrieveTypeface(hashKey);
            if (typeface == null && !string.IsNullOrEmpty(fontFamily))
            {
                string filename = fontFamily;
                if (filename.LastIndexOf(".", System.StringComparison.Ordinal) != filename.Length - 4)
                {
                    filename = string.Format("{0}.ttf", filename);
                }
                try
                {
                    var path = "fonts/" + filename;
                    typeface = Typeface.CreateFromAsset(context.Assets, path);
                }
                catch
                {
                    try
                    {
                        typeface = Typeface.CreateFromFile("fonts/" + filename);
                    }
                    catch
                    {
                    }
                }
            }
            if (typeface == null)
            {
                typeface = Typeface.Default;
            }
            TypefaceCache.SharedCache.StoreTypeface(hashKey, typeface);
            return typeface;
        }
        private static string ToHasmapKey(this Font font)
        {
            return string.Format("{0}.{1}.{2}.{3}", font.FontFamily, font.FontSize, font.NamedSize, (int)font.FontAttributes);
        }
        public static string ToHasmapKeyWithFontFamily(string fontFamily, double fontSize, string namedSize, int fontAttributes)
        {
            return string.Format("{0}.{1}.{2}.{3}", fontFamily, fontSize, namedSize, fontAttributes);
        }
    }
}