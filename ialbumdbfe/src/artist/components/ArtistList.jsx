import React from 'react';
import styled from 'styled-components';
import { useNavigate } from 'react-router-dom';

// Stateless component used only for rendering list of artist
// Artist are passed in and the list is rendered and styled based on that list

export default function ArtistList({ artists }) {
	const navigate = useNavigate();
	const navigateOnClick = (id) => {
		navigate(`/artists/${id}`);
	};

	const ListItem = styled.li`
		cursor: pointer;
		padding: 5px;
		background-color: #f9f8f7;
		color: #2e3138;
		&:hover,
		&:focus {
			background-color: #898889;
			color: #f9f8f7;
		}
	`;

	const ArtistNav = styled.button`
		font-weight: bolder;
		text-align: start;
		cursor: inherit;
		border: none;
		background-color: inherit;
		color: inherit;
		width: 100%;
		height: 100%;
	`;

	return (
		<ul>
			{artists.map((a) => (
				<ListItem key={a.id}>
					<ArtistNav onClick={() => navigateOnClick(a.id)}>
						{a.name}
					</ArtistNav>
				</ListItem>
			))}
		</ul>
	);
}
