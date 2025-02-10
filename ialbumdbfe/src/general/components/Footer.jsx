import React from 'react';

export default function Footer() {
	const year = new Date().getFullYear();

	return (
		<div className="footer">
			<p>Fake-Copyright {year} IMuDB. Some rights reserved.</p>
		</div>
	);
}
