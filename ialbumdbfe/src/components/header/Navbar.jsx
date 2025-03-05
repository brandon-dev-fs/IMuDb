import React from 'react';
import logo from '../../assets/logo/IMuDBRecordLogo.svg';
import { Link } from 'react-router-dom';

export default function Navbar() {
	return (
		<nav className="nav">
				<Link className="header-logo-button" to="/">
					<img
						className="header-logo"
						alt="Logo for Internet Music Database"
						src={logo}
					/>
				</Link>
				<Link className="nav-button" to="/artists">
					Artists
				</Link>
				<Link className="nav-button" to="/albums">
					Albums
				</Link>
		</nav>
	);
}
