import { Box, Button, Group, TextInput } from '@mantine/core';
import { useForm } from '@mantine/form';
import { useCreateShortenedUrl } from '../util/hooks/mutation/useCreateShortenedUrl';
import { useState } from 'react';
import { Link } from 'react-router-dom';

const CreateLinkBox = () => {
	const [link, setLink] = useState('');
	const [shortenedUrl, setShortenedUrl] = useState('');
	const { mutateAsync } = useCreateShortenedUrl(link);
	const form = useForm({
		initialValues: {
			url: '',
		},
	});

	const handleSubmit = async (url: string) => {
		setLink(url);
		const result = await mutateAsync(url);
		setShortenedUrl(result);
		form.reset();
	};

	return (
		<Box maw={300} mx='auto'>
			<form onSubmit={form.onSubmit((values) => handleSubmit(values.url))}>
				<TextInput
					label='Url'
					placeholder='Type an url to shorten'
					{...form.getInputProps('url')}
				/>

				<Group position='right' mt='md'>
					<Button type='submit'>Submit</Button>
				</Group>
			</form>
			{shortenedUrl !== '' ? (
				<h1>
					<Link to={shortenedUrl} target='_blank' rel='noopener noreferrer'>
						Your shortened url
					</Link>
				</h1>
			) : (
				<></>
			)}
		</Box>
	);
};

export default CreateLinkBox;
