import React from 'react';
import { Link } from 'react-router-dom';

export default function Navbar() {
	return (
		<nav>
			<Link className="button nav-link" to="/">
				Home
			</Link>
			<Link className="button nav-link" to="/artists">
				Artists
			</Link>
			<Link className="button nav-link" to="/albums">
				Albums
			</Link>
		</nav>
	);
}
