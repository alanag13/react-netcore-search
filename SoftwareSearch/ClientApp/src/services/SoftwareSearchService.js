export function getSoftwareWithHigherVersion(versionNumber) {
    return fetch(`/api/software/byversion/greaterthan/${versionNumber}`).then(
        (res) => res.json());
    }