import { useMutation } from "@tanstack/react-query";
import { AxiosError } from "axios";
import { createShortenedUrl } from "../../api/shortenedUrl";

const getUseCreateShortenedUrlKey = (longUrl: string) => [`create-shortened-url-${longUrl}`];

export const useCreateShortenedUrl = (longUrl: string) => {
	return useMutation<string, AxiosError, string>(
		getUseCreateShortenedUrlKey(longUrl),
		(longUrl) => createShortenedUrl(longUrl),
		{
			retry: false,
		}
	);
};