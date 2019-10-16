using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace FoodHub.Helpers
{
	public static class Helper
	{
		public static string EncryptMD5(string txt)
		{
			if (string.IsNullOrEmpty(txt))
				return null;

			var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
			var encoder = new UTF8Encoding();

			var originalBytes = encoder.GetBytes(txt);
			var encodedBytes = md5.ComputeHash(originalBytes);

			//return encodedBytes
			//		.Select(x => x.ToString("X2"))
			//		.ToString();

			return BitConverter
					.ToString(encodedBytes)
					.Replace("-", "")
					.ToLower();
		}

		//public static string GenerateSalt(int length)
		//{
		//	var rng = new RNGCryptoServiceProvider();
		//	var buffer = new byte[length];
		//	rng.GetBytes(buffer);

		//	return Convert.ToBase64String(buffer);
		//}

		//public static string CreatePasswordHash(string password, string saltkey,
		//	string passwordFormat = "SHA1")
		//{
		//	if (String.IsNullOrEmpty(passwordFormat))
		//		passwordFormat = "SHA1";
		//	string saltAndPassword = string.Concat(password, saltkey);
		//	string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(
		//			saltAndPassword, passwordFormat);

		//	return hashedPassword;
		//}
	}
}