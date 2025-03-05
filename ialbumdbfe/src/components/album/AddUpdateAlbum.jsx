import React, { useEffect, useState } from 'react';

export default function AddUpdateAlbum({ editableAlbum }) {
	const [album, setAlbum] = useState({});
	const [artists, setArtists] = useState([]);
	const [editMode, setEditMode] = useState(false);

	useEffect(() => {
		if (editableAlbum) {
			setEditMode(true);
			setAlbum(editableAlbum);
		}

		setArtists([
			{ id: 1, name: 'Mumford & Sons' },
			{ id: 2, name: 'John Mayer' },
			{ id: 3, name: 'The Beatles' },
		]);
	}, []);

	return (
		<div className="add-edit-form">
			{editMode ? <h3>Editing {album.name}</h3> : <h3>Add Album</h3>}
			<div>
				<label>Name: </label>
				<input type="text"></input>
			</div>
			<div>
				<label>Artist</label>
				<select>
					<option defaultValue={'Select Artist'}>
						Select Artist
					</option>
					{artists.map((a) => (
						<option key={a.id} value={a.name}>
							{a.name}
						</option>
					))}
				</select>
			</div>
			<div>
				<button>Add Songs</button>
			</div>
		</div>
	);
}
