import { useParams } from 'react-router-dom';
import RedirectComponent from '../components/redirectComponent';
import { Center, Loader } from '@mantine/core';

const ShortenedRedirect = () => {
	let { id } = useParams();

	if (id) return <RedirectComponent id={id} />;

	return (
		<Center w='100%' h='100%'>
			<Loader />;
		</Center>
	);
};

export default ShortenedRedirect;
