import { useQuery } from "@tanstack/react-query";
import { AxiosError } from "axios";
import { getShortenedUrl } from "../../api/shortenedUrl";

const getUseShortenedUrlKey = (id: string) => [`shortened-url-${id}`];

export const useShortenedUrl = (id: string) => {
	return useQuery<string, AxiosError>(
		getUseShortenedUrlKey(id),
		() => getShortenedUrl(id),
		{
			retry: false,
			staleTime: 0,
		}
	);
};