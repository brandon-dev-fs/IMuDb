import React, { useState, useEffect } from 'react';
import { getSongById } from '../../services/httprequest';

export default function Song({ albumId, song, setSong}) {
	const [songDetails, setSongDetails] = useState();

	const formatTime = (i) => {
		const min = Math.floor(i / 60);
		const sec = i % 60 < 10 ? '0' + (i % 60) : i % 60;

		return `${min}:${sec}`;
	};

	useEffect(() => {
		getSongById(albumId, song.id).then(data => {
			console.log(data)
			setSongDetails(data);
			setLoading(false);
		}).catch(e => {
			console.log(e);
			setSong(null);
		})
	}, [song]);

	const handleExit = () => {
		setSong(null);
		setSongDetails(null);
	}

	return (
		<div>
			<button type="button" onClick={() => handleExit()}>X</button>
			<span>{songDetails.track}</span>. <span>{songDetails.name}</span>{' '}
			<span>{formatTime(songDetails.length)}</span>
		</div>
	);
}
