export const ensureProtocol = (url: string) => {
    let protocol = "";
    try {
        var u = new URL(url);
        protocol = u.protocol.slice(0, -1);
    } catch (e) {}

    if(protocol === "") {
        return "https://" + url;
    }

    return url;
}
