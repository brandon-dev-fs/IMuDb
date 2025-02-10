import React from 'react';
import { useNavigate } from 'react-router-dom';

export default function Card({ album }) {
	//For on click navigation
	const navigate = useNavigate();
	const navigateOnClick = (id) => {
		navigate(`/albums/${id}`);
	};

	return (
		<div className="card" onClick={() => navigateOnClick(album.id)}>
			<div className="card-title">
				<h3>
					{album.name} ({album.year})
				</h3>
			</div>
		</div>
	);
}
