# Requirements

## Azure DevOps

The PAT requires at least the following scopes:

| Scope | Description | Reason
|-------|-------------|--------
| `vso.tokenadministration` | Token Administration (Read & manage) | Required to load Images from Endpoint `_api/_common/identityImage` (undocumented Endpoint!)
| `vso.tokenadministration` | Token Administration (Read & manage) | Required to load Identities from Endpoint `_apis/identities`
