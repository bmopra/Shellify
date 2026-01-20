using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Shellify.IO
{
	internal static class DefaultEncoding
	{
		private static int _codePage;
		private static Encoding _instance;

		public static int CodePage
		{
			get => _codePage;
			set
			{
				if (_codePage != value)
				{
					if (_instance is not null)
						_instance = CodePagesEncodingProvider.Instance.GetEncoding(value);
					_codePage = value;
				}
			}
		}

		public static Encoding Instance
		{
			get
			{
				if(_instance is null)
				{
					_instance = _codePage != 0 ?
						CodePagesEncodingProvider.Instance.GetEncoding(_codePage) :
						CodePagesEncodingProvider.Instance.GetEncoding(CultureInfo.CurrentCulture.TextInfo.ANSICodePage);
				}
				return _instance;
			}
		}
		
	}
}
