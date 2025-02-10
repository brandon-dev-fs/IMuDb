import React from 'react';
import Card from './AlbumCard';

export default function Grid({ items }) {
	// const getMembers = (i) => {
	// 	if (i.members != null) {
	// 		return (
	// 			<ul>
	// 				<p>Members</p>
	// 				{i.members.map((m, i) => (
	// 					<li key={i}>{m}</li>
	// 				))}
	// 			</ul>
	// 		);
	// 	}
	// };

	return (
		<div className="grid">
			{items.map((i) => (
				// <AlbumCard key={a.id} album={a}></AlbumCard>
				<Card key={i.id} album={i}></Card>
			))}
		</div>
	);
}
