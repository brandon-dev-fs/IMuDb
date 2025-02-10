import React, { useState } from 'react';

export default function AddUpdateArtistForm() {
	const [artistEdit, setArtist] = useState({
		name: '',
		members: [],
	});
	const [memberEdit, setMemberEdit] = useState('');

	const addMember = () => {
		console.log('addMember');
		setArtist({
			members: [...artistEdit.members, memberEdit],
		});
		setMemberEdit('');
	};

	const subMember = (i) => {
		console.log('subMember');
		setArtist({
			members: artistEdit.members.filter((m, id) => id !== i),
		});
	};

	const updateArtistName = (e) => {
		setArtist({
			name: e.target.value,
			members: artistEdit.members,
		});
	};

	const submit = (e) => {
		e.preventDefault();

		const ROOT_API = 'https://localhost:3001/api/';
		const url = `${ROOT_API}artist`;

		// const headers = new Headers();
		// headers.append('Content-Type', 'application/json');
		// headers.append('Accept', 'application/json');
		// //headers.append('Access-Control-Allow-Origin', '*');

		// const request = new Request(url, {
		// 	method: 'POST',
		// 	body: JSON.stringify(artistEdit),
		// 	mode: 'no-cors',
		// 	headers: headers,
		// });

		try {
			const response = fetch(url, {
				method: 'POST',
				body: JSON.stringify(artistEdit),
				mode: 'no-cors',
				headers: {
					Accept: 'application/json, text/plain',
					'Content-Type': 'application/json; charset=utf-8',
				},
			});
			// .then((d) => {
			// 	if (d.status === 200) {
			// 		setArtist({
			// 			name: '',
			// 			members: [],
			// 		});
			// 		setMemberEdit('');
			// 	} else {
			// 		throw d.text;
			// 	}
			//});
			console.log(response);
		} catch (error) {
			console.log(error);
		}
	};

	return (
		<div className="container">
			<div className="page-banner p-md">
				<h2>Add new artist</h2>
			</div>
			<form className=" p-md" onSubmit={submit}>
				<div className="p-sm">
					<label id="artist-name">Artist Name </label>
					<input
						type="text"
						htmlFor="artist-name"
						onChange={updateArtistName}
					/>
				</div>
				<div className="p-sm">
					<label>Members (leave blank if single artist)</label>
					<div>
						<input
							type="text"
							id=""
							value={memberEdit}
							onChange={(e) => {
								setMemberEdit(e.target.value);
							}}
						/>
						<button
							type="button"
							disabled={memberEdit === ''}
							onClick={addMember}
						>
							+
						</button>
					</div>
					{artistEdit.members.length > 0 &&
						artistEdit.members.map((m, i) => (
							<div key={i}>
								<span>
									{m}{' '}
									<button
										type="button"
										onClick={() => subMember(i)}
									>
										-
									</button>
								</span>
							</div>
						))}
				</div>
				<div className="p-sm">
					<button type="submit" disabled={artistEdit.name === ''}>
						Add
					</button>
				</div>
			</form>
		</div>
	);
}
