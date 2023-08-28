import { API } from "./API"


export const getShortenedUrl = async (id: string) => {
    return (await API.get<string>(`/api/v1/shorten/${id}`)).data
}

export const createShortenedUrl = async (longUrl: string) => {
    return (await API.post<string>(`/api/v1/shorten`, { longUrl })).data
}
