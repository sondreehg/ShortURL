import { useShortenedUrl } from '../util/hooks/queries/useShortenedUrl';
import { ensureProtocol } from '../util/urlUtils';
import NotFound from './notFound';

interface RedirectComponentProps {
	id: string;
}

const RedirectComponent = ({ id }: RedirectComponentProps) => {
	const { data: url, isError } = useShortenedUrl(id);
	if (isError) return <NotFound />;
	if (url) window.location.href = ensureProtocol(url);
	return <></>;
};

export default RedirectComponent;
