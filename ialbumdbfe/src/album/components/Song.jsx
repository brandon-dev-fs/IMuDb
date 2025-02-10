import React from 'react';

export default function Song({ song }) {
	const formatTime = (i) => {
		const min = Math.floor(i / 60);
		const sec = i % 60 < 10 ? '0' + (i % 60) : i % 60;

		return `${min}:${sec}`;
	};

	return (
		<div>
			<span>{song.track}</span>. <span>{song.name}</span>{' '}
			<span>{formatTime(song.length)}</span>
		</div>
	);
}
