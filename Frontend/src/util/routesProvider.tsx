import { RouterProvider, createBrowserRouter } from 'react-router-dom';
import ShortenedRedirect from '../pages/shortenedRedirect';
import Home from '../pages/home';
import NotFound from '../components/notFound';

const RoutesProvider = () => {
	const router = createBrowserRouter([
		{
			path: '/',
			element: <Home />,
		},
		{
			path: '/:id',
			element: <ShortenedRedirect />,
		},
		{
			path: '*',
			element: <NotFound />,
		},
	]);

	return <RouterProvider router={router} />;
};

export default RoutesProvider;
