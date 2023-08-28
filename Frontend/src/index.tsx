import React from 'react';
import ReactDOM from 'react-dom/client';
import { AppShell, MantineProvider } from '@mantine/core';
import RoutesProvider from './util/routesProvider';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import AppHeader from './components/appHeader';

const root = ReactDOM.createRoot(document.getElementById('root') as HTMLElement);
const queryClient = new QueryClient();
root.render(
	<React.StrictMode>
		<MantineProvider
			theme={{
				// Override any other properties from default theme
				fontFamily: 'Open Sans, sans serif',
				spacing: { xs: '1rem', sm: '1.2rem', md: '1.8rem', lg: '2.2rem', xl: '2.8rem' },
			}}
		>
			<QueryClientProvider client={queryClient}>
				<AppShell
					padding='md'
					header={<AppHeader />}
					styles={(theme) => ({
						main: {
							backgroundColor:
								theme.colorScheme === 'dark'
									? theme.colors.dark[8]
									: theme.colors.gray[0],
						},
					})}
				>
					<RoutesProvider />
				</AppShell>
			</QueryClientProvider>
		</MantineProvider>
	</React.StrictMode>
);
