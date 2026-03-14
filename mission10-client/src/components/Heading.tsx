type HeadingProps = {
    title: string;
    subtitle?: string;
};

const Heading = ({ title, subtitle }: HeadingProps) => {
    return (
        <header className="my-4 text-center">
            <h1>{title}</h1>
            {subtitle && <p>{subtitle}</p>}
        </header>
    );
};

export default Heading;
