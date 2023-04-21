using System;
using Microsoft.AspNetCore.StaticFiles;
namespace Infrastructure.Extensions
{
	public static class FileExtensionForBlob
	{
		private static readonly FileExtensionContentTypeProvider Provider = new FileExtensionContentTypeProvider();


		public static string GetContentType(this string fileName)
		{
			if (!Provider.TryGetContentType(fileName, out var contentType))
			{
				contentType = "application/octet-stream";
			}

			return contentType;
		}
		
	}
}

