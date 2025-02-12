import logo from '../../assets/logo/IMuDBRecordLogo.svg';
import Navbar from './Navbar';

export default function Header() {
	return (
		<div className="header">
			<img
				className="logo"
				alt="Logo for Internet Music Database"
				src={logo}
			/>
			<Navbar />
		</div>
	);
}
